import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import api from "../api/axiosInstance";
import { useAuthStore } from "../store/useAuthStore";
import SongForm from "../components/SongForm";

export default function AdminPanel() {
  const { role } = useAuthStore();
  const [songs, setSongs] = useState([]);

  useEffect(() => {
    if (role !== "admin") return;
    const fetchAdminSongs = async () => {
      try {
        const res = await api.get("/admin/songs");
        setSongs(res.data);
      } catch (error) {
        console.error("Error al obtener canciones:", error);
      }
    };
    fetchAdminSongs();
  }, [role]);

  const handleAddSong = async (data) => {
    try {
      const res = await api.post("/admin/songs", data);
      setSongs((prev) => [...prev, res.data]);
      alert("Canción agregada correctamente");
    } catch (error) {
      console.error("Error al agregar canción:", error);
      alert("Error al agregar canción");
    }
  };

  if (role !== "admin") {
    return <p>Acceso denegado. Solo administradores.</p>;
  }

  return (
    <>
      <Navbar />
      <div style={{ padding: "1rem" }}>
        <h2>Panel de Administración</h2>

        <h3>Agregar nueva canción</h3>
        <SongForm onSubmit={handleAddSong} />

        <h3>Lista de canciones</h3>
        <ul>
          {songs.map((song) => (
            <li key={song._id}>{song.title}</li>
          ))}
        </ul>
      </div>
    </>
  );
}
