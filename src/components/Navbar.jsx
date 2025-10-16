import { Link, useLocation } from "wouter";
import { useAuthStore } from "../store/useAuthStore";

export default function Navbar() {
  const { user, logout } = useAuthStore();
  const [, setLocation] = useLocation();

  const handleLogout = () => {
    logout();
    setLocation("/login");
  };

  return (
    <nav
      style={{
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        padding: "1rem",
        background: "#222",
        color: "white",
      }}
    >
      <div style={{ display: "flex", gap: "1rem" }}>
        <Link href="/">Inicio</Link>
        <Link href="/songs">Canciones</Link>
        {!user && <Link href="/login">Login</Link>}
        {!user && <Link href="/register">Registro</Link>}
        {user?.role === "admin" && <Link href="/admin">Admin</Link>}
      </div>

      {user ? (
        <div style={{ display: "flex", alignItems: "center", gap: "1rem" }}>
          <span>👤 {user.name}</span>
          <button
            onClick={handleLogout}
            style={{ background: "crimson", color: "white" }}
          >
            Cerrar sesión
          </button>
        </div>
      ) : (
        <span>No autenticado</span>
      )}
    </nav>
  );
}
