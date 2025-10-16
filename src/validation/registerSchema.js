import { z } from "zod";

export const registerSchema = z
  .object({
    name: z.string().min(2, "el nombre debe tener al menos 2 caracteres"),
    email: z.string().email("formato de email invalido"),
    password: z
      .string()
      .min(6, "la contrasenia debe tener al menos 6 caracteres"),
    confirmPassword: z.string().min(6, "debes confirmar tu contrasenia"),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "las contrasenias no coinciden",
    path: ["confirmPassword"],
  });
