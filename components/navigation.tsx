"use client"

import Link from "next/link"
import { Music } from "lucide-react"

export default function Navigation() {
  return (
    <nav className="bg-card border-b border-border sticky top-0 z-50">
      <div className="container mx-auto px-4 py-4">
        <div className="flex items-center justify-between">
          {/* Logo */}
          <Link href="/" className="flex items-center gap-2 hover:opacity-80 transition-opacity">
            <Music className="w-6 h-6 text-primary" />
            <span className="text-xl font-bold text-foreground">MusicHub</span>
          </Link>

          {/* Links */}
          <div className="hidden md:flex items-center gap-8">
            <Link href="/" className="text-foreground hover:text-primary transition-colors">
              Canciones
            </Link>
            <Link href="/manage" className="text-foreground hover:text-primary transition-colors">
              Gestionar
            </Link>
            <Link href="/users" className="text-foreground hover:text-primary transition-colors">
              Usuarios
            </Link>
            <Link
              href="/auth"
              className="px-4 py-2 bg-primary text-primary-foreground rounded-lg hover:bg-primary/90 transition-colors font-medium"
            >
              Cuenta
            </Link>
          </div>

          {/* Mobile menu button */}
          <button className="md:hidden text-foreground hover:text-primary transition-colors">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16M4 18h16" />
            </svg>
          </button>
        </div>
      </div>
    </nav>
  )
}
