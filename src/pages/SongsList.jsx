import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import api from "../api/axiosInstance";
import { Link } from "wouter";

export default function SongsList() {
  const [songs, setSongs] = useState([]);

  useEffect(() => {
    const fetchSongs = async () => {
      try {
        const res = await api.get("/songs");
        setSongs(res.data);
      } catch (error) {
        console.error("Error al obtener canciones:", error);
      }
    };
    fetchSongs();
  }, []);

  return (
    <>
      <Navbar />
      <div style={{ padding: "1rem" }}>
        <h2>Lista de Canciones</h2>
        {songs.length > 0 ? (
          <ul>
            {songs.map((song) => (
              <li key={song._id}>
                <Link href={`/songs/${song._id}`}>{song.title}</Link>
              </li>
            ))}
          </ul>
        ) : (
          <p>No hay canciones disponibles.</p>
        )}
      </div>
    </>
  );
}
