"use client"

import type React from "react"

import { useState } from "react"
import Navigation from "@/components/navigation"
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"

export default function ManagePage() {
  const [albums, setAlbums] = useState<{ name: string; year: string }[]>([])
  const [artists, setArtists] = useState<{ name: string; country: string }[]>([])
  const [songs, setSongs] = useState<{ title: string; artist: string; album: string; genres: string }[]>([])
  const [genres, setGenres] = useState<{ name: string }[]>([])

  const [albumForm, setAlbumForm] = useState({ name: "", year: "" })
  const [artistForm, setArtistForm] = useState({ name: "", country: "" })
  const [songForm, setSongForm] = useState({ title: "", artist: "", album: "", genres: "" })
  const [genreForm, setGenreForm] = useState({ name: "" })

  const handleAddAlbum = (e: React.FormEvent) => {
    e.preventDefault()
    if (albumForm.name && albumForm.year) {
      setAlbums([...albums, albumForm])
      setAlbumForm({ name: "", year: "" })
    }
  }

  const handleAddArtist = (e: React.FormEvent) => {
    e.preventDefault()
    if (artistForm.name && artistForm.country) {
      setArtists([...artists, artistForm])
      setArtistForm({ name: "", country: "" })
    }
  }

  const handleAddSong = (e: React.FormEvent) => {
    e.preventDefault()
    if (songForm.title && songForm.artist && songForm.album) {
      setSongs([...songs, songForm])
      setSongForm({ title: "", artist: "", album: "", genres: "" })
    }
  }

  const handleAddGenre = (e: React.FormEvent) => {
    e.preventDefault()
    if (genreForm.name) {
      setGenres([...genres, genreForm])
      setGenreForm({ name: "" })
    }
  }

  return (
    <div className="min-h-screen bg-background">
      <Navigation />

      <main className="container mx-auto px-4 py-12">
        <div className="mb-12">
          <h1 className="text-5xl font-bold text-foreground mb-2">Gestión de Contenido</h1>
          <p className="text-muted-foreground text-lg">Administra álbumes, artistas y canciones</p>
        </div>

        <Tabs defaultValue="albums" className="w-full">
          <TabsList className="grid w-full grid-cols-4">
            <TabsTrigger value="albums">Álbumes</TabsTrigger>
            <TabsTrigger value="artists">Artistas</TabsTrigger>
            <TabsTrigger value="genres">Géneros</TabsTrigger>
            <TabsTrigger value="songs">Canciones</TabsTrigger>
          </TabsList>

          <TabsContent value="albums" className="space-y-6">
            <div className="bg-card rounded-lg p-8 border border-border">
              <h2 className="text-2xl font-bold text-foreground mb-6">Agregar Álbum</h2>
              <form onSubmit={handleAddAlbum} className="space-y-4">
                <div>
                  <Label className="text-foreground">Nombre del Álbum</Label>
                  <Input
                    value={albumForm.name}
                    onChange={(e) => setAlbumForm({ ...albumForm, name: e.target.value })}
                    placeholder="Ej: After Hours"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">IdArtista </Label>
                  <Input
                    type="number"
                    value={albumForm.year}
                    onChange={(e) => setAlbumForm({ ...albumForm, year: e.target.value })}
                    className="mt-2"
                  />
                </div>
                <Button type="submit" className="bg-primary hover:bg-primary/90">
                  Agregar Álbum
                </Button>
              </form>
            </div>

            {albums.length > 0 && (
              <div className="bg-card rounded-lg p-8 border border-border">
                <h3 className="text-xl font-bold text-foreground mb-4">Álbumes Agregados</h3>
                <div className="space-y-2">
                  {albums.map((album, idx) => (
                    <div key={idx} className="flex justify-between items-center p-3 bg-secondary rounded-lg">
                      <div>
                        <p className="text-foreground font-medium">{album.name}</p>
                        <p className="text-sm text-muted-foreground">{album.year}</p>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            )}
          </TabsContent>

          <TabsContent value="artists" className="space-y-6">
            <div className="bg-card rounded-lg p-8 border border-border">
              <h2 className="text-2xl font-bold text-foreground mb-6">Agregar Artista</h2>
              <form onSubmit={handleAddArtist} className="space-y-4">
                <div>
                  <Label className="text-foreground">Nombre del Artista</Label>
                  <Input
                    value={artistForm.name}
                    onChange={(e) => setArtistForm({ ...artistForm, name: e.target.value })}
                    placeholder="Ej: The Weeknd"
                    className="mt-2"
                  />
                </div>

                <Button type="submit" className="bg-primary hover:bg-primary/90">
                  Agregar Artista
                </Button>
              </form>
            </div>

            {artists.length > 0 && (
              <div className="bg-card rounded-lg p-8 border border-border">
                <h3 className="text-xl font-bold text-foreground mb-4">Artistas Agregados</h3>
                <div className="space-y-2">
                  {artists.map((artist, idx) => (
                    <div key={idx} className="flex justify-between items-center p-3 bg-secondary rounded-lg">
                      <div>
                        <p className="text-foreground font-medium">{artist.name}</p>
                        <p className="text-sm text-muted-foreground">{artist.country}</p>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            )}
          </TabsContent>

          <TabsContent value="genres" className="space-y-6">
            <div className="bg-card rounded-lg p-8 border border-border">
              <h2 className="text-2xl font-bold text-foreground mb-6">Agregar Género</h2>
              <form onSubmit={handleAddGenre} className="space-y-4">
                <div>
                  <Label className="text-foreground">Nombre del Género</Label>
                  <Input
                    value={genreForm.name}
                    onChange={(e) => setGenreForm({ name: e.target.value })}
                    placeholder="Ej: Rock, Pop, Jazz"
                    className="mt-2"
                  />
                </div>
                <Button type="submit" className="bg-primary hover:bg-primary/90">
                  Agregar Género
                </Button>
              </form>
            </div>

            {genres.length > 0 && (
              <div className="bg-card rounded-lg p-8 border border-border">
                <h3 className="text-xl font-bold text-foreground mb-4">Géneros Agregados</h3>
                <div className="space-y-2">
                  {genres.map((genre, idx) => (
                    <div key={idx} className="flex justify-between items-center p-3 bg-secondary rounded-lg">
                      <div>
                        <p className="text-foreground font-medium">{genre.name}</p>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            )}
          </TabsContent>

          <TabsContent value="songs" className="space-y-6">
            <div className="bg-card rounded-lg p-8 border border-border">
              <h2 className="text-2xl font-bold text-foreground mb-6">Agregar Canción</h2>
              <form onSubmit={handleAddSong} className="space-y-4">
                <div>
                  <Label className="text-foreground">Título de la Canción</Label>
                  <Input
                    value={songForm.title}
                    onChange={(e) => setSongForm({ ...songForm, title: e.target.value })}
                    placeholder="Ej: Blinding Lights"
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">IdArtista</Label>
                  <Input
                    value={songForm.artist}
                    onChange={(e) => setSongForm({ ...songForm, artist: e.target.value })}
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">IdÁlbum</Label>
                  <Input
                    value={songForm.album}
                    onChange={(e) => setSongForm({ ...songForm, album: e.target.value })}
                    className="mt-2"
                  />
                </div>
                <div>
                  <Label className="text-foreground">IDs de Géneros (separados por comas)</Label>
                  <Input
                    value={songForm.genres}
                    onChange={(e) => setSongForm({ ...songForm, genres: e.target.value })}
                    placeholder="Ej: 1,2,5"
                    className="mt-2"
                  />
                </div>
                <Button type="submit" className="bg-primary hover:bg-primary/90">
                  Agregar Canción
                </Button>
              </form>
            </div>

            {songs.length > 0 && (
              <div className="bg-card rounded-lg p-8 border border-border">
                <h3 className="text-xl font-bold text-foreground mb-4">Canciones Agregadas</h3>
                <div className="space-y-2">
                  {songs.map((song, idx) => (
                    <div key={idx} className="flex justify-between items-center p-3 bg-secondary rounded-lg">
                      <div>
                        <p className="text-foreground font-medium">{song.title}</p>
                        <p className="text-sm text-muted-foreground">
                          {song.artist} - {song.album}
                        </p>
                        {song.genres && <p className="text-xs text-muted-foreground mt-1">Géneros: {song.genres}</p>}
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            )}
          </TabsContent>
        </Tabs>
      </main>
    </div>
  )
}
