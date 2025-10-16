import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { songSchema } from "../validation/songSchema";

export default function SongForm({ onSubmit, defaultValues = {} }) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(songSchema),
    defaultValues,
  });

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      style={{ display: "flex", flexDirection: "column", gap: "0.5rem" }}
    >
      <input {...register("title")} placeholder="titulo" />
      {errors.title && <p style={{ color: "red" }}>{errors.title.message}</p>}

      <input {...register("artist")} placeholder="Artista" />
      {errors.artist && <p style={{ color: "red" }}>{errors.artist.message}</p>}

      <input {...register("album")} placeholder="album (opcional)" />

      <input {...register("genre")} placeholder="genero" />
      {errors.genre && <p style={{ color: "red" }}>{errors.genre.message}</p>}

      <button type="submit" style={{ marginTop: "1rem" }}>
        save 💾
      </button>
    </form>
  );
}
