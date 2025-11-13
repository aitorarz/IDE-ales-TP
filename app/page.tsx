"use client"

import { useState } from "react"
import Link from "next/link"
import Navigation from "@/components/navigation"
import SongCard from "@/components/song-card"

export default function SongsPage() {
  const [songs] = useState([
    { id: 1, title: "Blinding Lights", artist: "The Weeknd", album: "After Hours" },
    { id: 2, title: "Shape of You", artist: "Ed Sheeran", album: "Divide" },
    { id: 3, title: "Levitating", artist: "Dua Lipa", album: "Future Nostalgia" },
    { id: 4, title: "Anti-Hero", artist: "Taylor Swift", album: "Midnights" },
    { id: 5, title: "As It Was", artist: "Harry Styles", album: "Harry's House" },
    { id: 6, title: "Heat Waves", artist: "Glass Animals", album: "Dreamland" },
  ])

  return (
    <div className="min-h-screen bg-background">
      <Navigation />

      <main className="container mx-auto px-4 py-12">
        <div className="mb-12">
          <h1 className="text-5xl font-bold text-foreground mb-2">Canciones</h1>
          <p className="text-muted-foreground text-lg">Explora nuestro catálogo completo de canciones</p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {songs.map((song) => (
            <Link key={song.id} href={`/song/${song.id}`}>
              <SongCard song={song} />
            </Link>
          ))}
        </div>
      </main>
    </div>
  )
}
