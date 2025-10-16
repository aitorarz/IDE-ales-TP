import { create } from "zustand";
import { z } from "zod";

export const useAuthStore = create((set) => ({
  user: null,
  token: null,
  role: null,

  login: ({ user, token, role }) => set({ user, token, role }),
  logout: () => set({ user: null, token: null, role: null }),
}));
