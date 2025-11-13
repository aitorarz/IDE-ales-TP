import { z } from "zod";

export const songSchema = z.object({
  title: z.string().min(2, "el titulo debe tener al menos 2 caracteres"),
  artist: z.string().min(2, "el nombre del artista es obligatorio"),
  album: z.string().optional(),
  genre: z.string().min(2, "tenes que especificar un genero"),
});
