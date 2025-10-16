import { z } from "zod";

export const loginSchema = z.object({
  email: z.string().email("email invalido"),
  password: z.string().min(6, "minimo 6 caracteres"),
});
