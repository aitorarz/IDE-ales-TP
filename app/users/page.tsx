"use client"

import type React from "react"

import { useState } from "react"
import Navigation from "@/components/navigation"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { UserIcon } from "lucide-react"

interface User {
  id: number
  name: string
  email: string
  roles: string[] // Changed from single role to array of roles
}

export default function UsersPage() {
  const [users, setUsers] = useState<User[]>([
    { id: 1, name: "Juan Pérez", email: "juan@example.com", roles: ["Admin"] },
    { id: 2, name: "María García", email: "maria@example.com", roles: ["Usuario"] },
    { id: 3, name: "Carlos López", email: "carlos@example.com", roles: ["Usuario"] },
  ])

  const [formData, setFormData] = useState({ name: "", email: "", selectedRoles: [] as string[] })

  const roleOptions = ["Usuario", "Mod", "Admin"]

  const handleRoleChange = (role: string) => {
    setFormData((prev) => ({
      ...prev,
      selectedRoles: prev.selectedRoles.includes(role)
        ? prev.selectedRoles.filter((r) => r !== role)
        : [...prev.selectedRoles, role],
    }))
  }

  const handleAddUser = (e: React.FormEvent) => {
    e.preventDefault()
    if (formData.name && formData.email && formData.selectedRoles.length > 0) {
      const newUser: User = {
        id: users.length + 1,
        name: formData.name,
        email: formData.email,
        roles: formData.selectedRoles,
      }
      setUsers([...users, newUser])
      setFormData({ name: "", email: "", selectedRoles: [] })
    }
  }

  const handleDeleteUser = (id: number) => {
    setUsers(users.filter((user) => user.id !== id))
  }

  return (
    <div className="min-h-screen bg-background">
      <Navigation />

      <main className="container mx-auto px-4 py-12">
        <div className="mb-12">
          <h1 className="text-5xl font-bold text-foreground mb-2">Gestión de Usuarios</h1>
          <p className="text-muted-foreground text-lg">Administra los usuarios registrados en la plataforma</p>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Formulario */}
          <div className="lg:col-span-1">
            <div className="bg-card rounded-lg p-6 border border-border sticky top-20">
              <h2 className="text-2xl font-bold text-foreground mb-6">Crear Usuario</h2>
              <form onSubmit={handleAddUser} className="space-y-4">
                <div>
                  <Label className="text-foreground">Nombre Completo</Label>
                  <Input
                    value={formData.name}
                    onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                    placeholder="Nombre completo"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">Email</Label>
                  <Input
                    type="email"
                    value={formData.email}
                    onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                    placeholder="correo@example.com"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground mb-3 block">Roles</Label>
                  <div className="space-y-2">
                    {roleOptions.map((role) => (
                      <div key={role} className="flex items-center">
                        <input
                          type="checkbox"
                          id={role}
                          checked={formData.selectedRoles.includes(role)}
                          onChange={() => handleRoleChange(role)}
                          className="w-4 h-4 bg-input border-border rounded cursor-pointer accent-primary"
                        />
                        <label htmlFor={role} className="ml-2 text-foreground cursor-pointer">
                          {role}
                        </label>
                      </div>
                    ))}
                  </div>
                  {formData.selectedRoles.length === 0 && (
                    <p className="text-xs text-destructive mt-2">Selecciona al menos un rol</p>
                  )}
                </div>
                <Button
                  type="submit"
                  className="w-full bg-primary hover:bg-primary/90"
                  disabled={formData.selectedRoles.length === 0}
                >
                  Agregar Usuario
                </Button>
              </form>
            </div>
          </div>

          {/* Lista de usuarios */}
          <div className="lg:col-span-2">
            <div className="bg-card rounded-lg p-6 border border-border">
              <h2 className="text-2xl font-bold text-foreground mb-6">Usuarios Registrados ({users.length})</h2>
              <div className="space-y-3">
                {users.map((user) => (
                  <div
                    key={user.id}
                    className="flex items-center justify-between p-4 bg-secondary rounded-lg border border-border hover:border-primary transition-colors"
                  >
                    <div className="flex items-center gap-4">
                      <div className="w-12 h-12 bg-primary rounded-full flex items-center justify-center flex-shrink-0">
                        <UserIcon size={24} className="text-primary-foreground" />
                      </div>
                      <div>
                        <p className="text-foreground font-semibold">{user.name}</p>
                        <p className="text-sm text-muted-foreground">{user.email}</p>
                      </div>
                    </div>
                    <div className="flex items-center gap-4">
                      <div className="flex gap-2">
                        {user.roles.map((role) => (
                          <span
                            key={role}
                            className="px-3 py-1 bg-primary/20 text-primary rounded-full text-sm font-medium"
                          >
                            {role}
                          </span>
                        ))}
                      </div>
                      <Button onClick={() => handleDeleteUser(user.id)} variant="destructive" size="sm">
                        Eliminar
                      </Button>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>
      </main>
    </div>
  )
}
