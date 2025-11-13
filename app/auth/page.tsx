"use client"

import type React from "react"

import { useState } from "react"
import Link from "next/link"
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Music } from "lucide-react"

export default function AuthPage() {
  const [loginForm, setLoginForm] = useState({ email: "", password: "" })
  const [registerForm, setRegisterForm] = useState({ name: "", email: "", password: "", confirmPassword: "" })
  const [loginError, setLoginError] = useState("")
  const [registerError, setRegisterError] = useState("")

  const handleLogin = (e: React.FormEvent) => {
    e.preventDefault()
    setLoginError("")
    if (!loginForm.email || !loginForm.password) {
      setLoginError("Por favor completa todos los campos")
      return
    }
    // Aquí iría la lógica de autenticación
    console.log("Login:", loginForm)
    setLoginForm({ email: "", password: "" })
  }

  const handleRegister = (e: React.FormEvent) => {
    e.preventDefault()
    setRegisterError("")
    if (!registerForm.name || !registerForm.email || !registerForm.password || !registerForm.confirmPassword) {
      setRegisterError("Por favor completa todos los campos")
      return
    }
    if (registerForm.password !== registerForm.confirmPassword) {
      setRegisterError("Las contraseñas no coinciden")
      return
    }
    console.log("Register:", registerForm)
    setRegisterForm({ name: "", email: "", password: "", confirmPassword: "" })
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-primary/20 via-background to-accent/20 flex items-center justify-center px-4">
      <div className="w-full max-w-md">
        {/* Logo y título */}
        <div className="text-center mb-10">
          <div className="flex items-center justify-center gap-2 mb-4">
            <Music className="w-10 h-10 text-primary" />
            <h1 className="text-3xl font-bold text-foreground">MusicHub</h1>
          </div>
          <p className="text-muted-foreground">Tu plataforma de gestión musical</p>
        </div>

        {/* Tabs de Login y Registro */}
        <div className="bg-card rounded-lg p-8 border border-border shadow-lg">
          <Tabs defaultValue="login" className="w-full">
            <TabsList className="grid w-full grid-cols-2 mb-6">
              <TabsTrigger value="login">Iniciar Sesión</TabsTrigger>
              <TabsTrigger value="register">Registrarse</TabsTrigger>
            </TabsList>

            {/* Login Tab */}
            <TabsContent value="login">
              <form onSubmit={handleLogin} className="space-y-4">
                {loginError && (
                  <div className="p-3 bg-destructive/10 text-destructive rounded-lg text-sm">{loginError}</div>
                )}
                <div>
                  <Label className="text-foreground">Email</Label>
                  <Input
                    type="email"
                    value={loginForm.email}
                    onChange={(e) => setLoginForm({ ...loginForm, email: e.target.value })}
                    placeholder="correo@example.com"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">Contraseña</Label>
                  <Input
                    type="password"
                    value={loginForm.password}
                    onChange={(e) => setLoginForm({ ...loginForm, password: e.target.value })}
                    placeholder="Tu contraseña"
                    className="mt-2"
                  />
                </div>
                <Button type="submit" className="w-full bg-primary hover:bg-primary/90 mt-6">
                  Iniciar Sesión
                </Button>
              </form>
            </TabsContent>

            {/* Register Tab */}
            <TabsContent value="register">
              <form onSubmit={handleRegister} className="space-y-4">
                {registerError && (
                  <div className="p-3 bg-destructive/10 text-destructive rounded-lg text-sm">{registerError}</div>
                )}
                <div>
                  <Label className="text-foreground">Nombre Completo</Label>
                  <Input
                    value={registerForm.name}
                    onChange={(e) => setRegisterForm({ ...registerForm, name: e.target.value })}
                    placeholder="Tu nombre"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">Email</Label>
                  <Input
                    type="email"
                    value={registerForm.email}
                    onChange={(e) => setRegisterForm({ ...registerForm, email: e.target.value })}
                    placeholder="correo@example.com"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">Contraseña</Label>
                  <Input
                    type="password"
                    value={registerForm.password}
                    onChange={(e) => setRegisterForm({ ...registerForm, password: e.target.value })}
                    placeholder="Crea una contraseña"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">Confirmar Contraseña</Label>
                  <Input
                    type="password"
                    value={registerForm.confirmPassword}
                    onChange={(e) => setRegisterForm({ ...registerForm, confirmPassword: e.target.value })}
                    placeholder="Confirma tu contraseña"
                    className="mt-2"
                  />
                </div>
                <Button type="submit" className="w-full bg-primary hover:bg-primary/90 mt-6">
                  Registrarse
                </Button>
              </form>
            </TabsContent>
          </Tabs>
        </div>

        {/* Footer */}
        <div className="text-center mt-6">
          <p className="text-sm text-muted-foreground">
            ¿Necesitas ayuda?{" "}
            <Link href="#" className="text-primary hover:underline">
              Contacta con soporte
            </Link>
          </p>
        </div>
      </div>
    </div>
  )
}
