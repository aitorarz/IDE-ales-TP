import { useEffect, useState } from "react";
import { useRoute } from "wouter";
import Navbar from "../components/Navbar";
import api from "../api/axiosInstance";

export default function SongDetail() {
  const [, params] = useRoute("/songs/:id");
  const [song, setSong] = useState(null);

  useEffect(() => {
    const fetchSong = async () => {
      try {
        const res = await api.get(`/songs/${params.id}`);
        setSong(res.data);
      } catch (error) {
        console.error("Error al cargar la canción:", error);
      }
    };
    fetchSong();
  }, [params.id]);

  if (!song) return <p>Cargando cancion...</p>;

  return (
    <>
      <Navbar />
      <div style={{ padding: "1rem" }}>
        <h2>{song.title}</h2>
        <p>Artista: {song.artist}</p>
        <p>Álbum: {song.album}</p>
        <p>Género: {song.genre}</p>
      </div>
    </>
  );
}
