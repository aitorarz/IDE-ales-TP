"use client"

import { Music2 } from "lucide-react"

interface SongCardProps {
  song: {
    id: number
    title: string
    artist: string
    album: string
  }
}

export default function SongCard({ song }: SongCardProps) {
  return (
    <div className="group bg-card rounded-lg p-6 border border-border hover:border-primary transition-all duration-300 hover:shadow-lg hover:shadow-primary/20 cursor-pointer">
      <div className="mb-4 w-full h-32 bg-gradient-to-br from-primary to-accent rounded-lg flex items-center justify-center group-hover:scale-105 transition-transform duration-300">
        <Music2 size={48} className="text-primary-foreground" />
      </div>

      <h3 className="text-lg font-bold text-foreground mb-2 line-clamp-2 group-hover:text-primary transition-colors">
        {song.title}
      </h3>

      <p className="text-primary font-semibold mb-1">{song.artist}</p>

      <p className="text-sm text-muted-foreground">{song.album}</p>
    </div>
  )
}
