import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { loginSchema } from "../validation/loginSchema";
import api from "../api/axiosInstance";
import { useAuthStore } from "../store/useAuthStore";

export default function Login() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(loginSchema),
  });

  const { login } = useAuthStore();

  const onSubmit = async (data) => {
    try {
      const res = await api.post("/auth/login", data);
      login({
        user: res.data.user,
        token: res.data.token,
        role: res.data.role,
      });
    } catch (err) {
      alert("Credenciales incorrectas");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("email")} placeholder="Email" />
      {errors.email && <p>{errors.email.message}</p>}

      <input
        {...register("password")}
        type="password"
        placeholder="Contraseña"
      />
      {errors.password && <p>{errors.password.message}</p>}

      <button type="submit">Ingresar</button>
    </form>
  );
}
