import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { registerSchema } from "../validation/registerSchema";
import api from "../api/axiosInstance";
import { useAuthStore } from "../store/useAuthStore";
import { useLocation } from "wouter";

export default function Register() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(registerSchema),
  });

  const { login } = useAuthStore();
  const [, setLocation] = useLocation();

  const onSubmit = async (data) => {
    try {
      const res = await api.post("/auth/register", data);
      login({
        user: res.data.user,
        token: res.data.token,
        role: res.data.role,
      });
      alert("registro exitoso");
      setLocation("/");
    } catch (error) {
      alert(
        "error al registrarse: " +
          (error.response?.data?.message || "intenta mas tarde")
      );
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "2rem auto" }}>
      <h2>Registro de Usuario</h2>
      <form
        onSubmit={handleSubmit(onSubmit)}
        style={{ display: "flex", flexDirection: "column", gap: "0.5rem" }}
      >
        <input {...register("name")} placeholder="nombre completo" />
        {errors.name && <p style={{ color: "red" }}>{errors.name.message}</p>}

        <input {...register("email")} placeholder="correo electronico" />
        {errors.email && <p style={{ color: "red" }}>{errors.email.message}</p>}

        <input
          {...register("password")}
          type="password"
          placeholder="contrasenia"
        />
        {errors.password && (
          <p style={{ color: "red" }}>{errors.password.message}</p>
        )}

        <input
          {...register("confirmPassword")}
          type="password"
          placeholder="confirmar contrasenia"
        />
        {errors.confirmPassword && (
          <p style={{ color: "red" }}>{errors.confirmPassword.message}</p>
        )}

        <button type="submit" style={{ marginTop: "1rem" }}>
          registrarse
        </button>
      </form>
    </div>
  );
}
