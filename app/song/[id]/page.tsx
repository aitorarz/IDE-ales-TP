"use client"

import { useState } from "react"
import Link from "next/link"
import Navigation from "@/components/navigation"
import { Button } from "@/components/ui/button"
import { Music2 } from "lucide-react"

export default function SongDetailPage({ params }: { params: { id: string } }) {
  const [songs] = useState({
    1: {
      title: "Blinding Lights",
      artist: "The Weeknd",
      album: "After Hours",
      genres: ["Synthwave", "Electropop", "Dark Wave"],
    },
    2: { title: "Shape of You", artist: "Ed Sheeran", album: "Divide", genres: ["Pop", "Dance-Pop"] },
    3: {
      title: "Levitating",
      artist: "Dua Lipa",
      album: "Future Nostalgia",
      genres: ["Disco-Pop", "Dance-Pop", "Synth-pop"],
    },
    4: { title: "Anti-Hero", artist: "Taylor Swift", album: "Midnights", genres: ["Pop", "Alternative Pop"] },
    5: { title: "As It Was", artist: "Harry Styles", album: "Harry's House", genres: ["Pop", "Soft Rock"] },
    6: {
      title: "Heat Waves",
      artist: "Glass Animals",
      album: "Dreamland",
      genres: ["Psychedelic Pop", "Indie Pop", "Alternative"],
    },
  })

  const song = songs[params.id as keyof typeof songs]

  if (!song) {
    return (
      <div className="min-h-screen bg-background">
        <Navigation />
        <div className="container mx-auto px-4 py-12 text-center">
          <p className="text-muted-foreground text-xl">Canción no encontrada</p>
        </div>
      </div>
    )
  }

  return (
    <div className="min-h-screen bg-background">
      <Navigation />

      <main className="container mx-auto px-4 py-12">
        <Link href="/">
          <Button variant="outline" className="mb-8 bg-transparent">
            ← Volver
          </Button>
        </Link>

        <div className="max-w-2xl mx-auto">
          <div className="bg-card rounded-lg p-8 border border-border">
            <div className="flex items-start gap-6 mb-8">
              <div className="w-24 h-24 bg-primary rounded-lg flex items-center justify-center flex-shrink-0">
                <Music2 size={48} className="text-primary-foreground" />
              </div>

              <div className="flex-1">
                <h1 className="text-4xl font-bold text-foreground mb-2">{song.title}</h1>
                <p className="text-xl text-primary mb-4">{song.artist}</p>
              </div>
            </div>

            <div className="space-y-6">
              <div>
                <h3 className="text-sm font-semibold text-muted-foreground uppercase tracking-wide mb-2">Álbum</h3>
                <p className="text-lg text-foreground">{song.album}</p>
              </div>

              <div>
                <h3 className="text-sm font-semibold text-muted-foreground uppercase tracking-wide mb-3">Géneros</h3>
                <div className="flex flex-wrap gap-2">
                  {song.genres.map((genre, idx) => (
                    <span
                      key={idx}
                      className="bg-primary text-primary-foreground px-4 py-2 rounded-full text-sm font-medium"
                    >
                      {genre}
                    </span>
                  ))}
                </div>
              </div>
            </div>
          </div>
        </div>
      </main>
    </div>
  )
}
