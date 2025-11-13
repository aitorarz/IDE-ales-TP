# IDE-ales-TP

# 📖 Documentacion de api

## 🎵 SongController.cs

- Endpoint: /api/canciones (GET)

Devuelve List<Song>, es decir, todas las canciones registradas en el sistema.

- Endpoint: /api/canciones/{id} (GET)

Devuelve un Song específico según su ID. Si no existe, devuelve un mensaje de error (404).

- Endpoint: /api/canciones/crear (POST)

Requiere en el body un objeto CreateSongDTO con los datos de la nueva canción (por ejemplo: título, duración, ID del álbum, ID del género, etc.).
Devuelve el Song creado (201 Created).

- Endpoint: /api/canciones/eliminar/{id} (DELETE)

Elimina la canción cuyo ID coincida con el parámetro.
Devuelve un mensaje de confirmación (HttpMessage) o un error si no existe.

- Endpoint: /api/canciones/actualizar/{id} (PUT)

Requiere en el body un objeto UpdateSongDTO con los campos a modificar.
Devuelve el Song actualizado.

## 🎼 AlbumController.cs

- Endpoint: /api/albumes (GET)

Devuelve List<Album> con todos los álbumes del sistema.

- Endpoint: /api/albumes/{id} (GET)

Devuelve un Album específico según su ID.

- Endpoint: /api/albumes/crear (POST)

Requiere en el body un CreateAlbumDTO con los datos del nuevo álbum (nombre, año, artista, etc.).
Devuelve el Album creado (201 Created).

- Endpoint: /api/albumes/eliminar/{id} (DELETE)

Elimina el álbum identificado por el ID.
Devuelve un mensaje (HttpMessage) confirmando la eliminación.

- Endpoint: /api/albumes/actualizar/{id} (PUT)

Requiere un UpdateAlbumDTO con los cambios a aplicar.
Devuelve el Album actualizado.

## 🎨 ArtistController.cs

- Endpoint: /api/artistas (GET)

Devuelve List<Artist> con todos los artistas registrados.

- Endpoint: /api/artistas/{id} (GET)

Devuelve un Artist específico por su ID.

- Endpoint: /api/artistas/crear (POST)

Requiere un CreateOrUpdateArtistDTO con los datos del nuevo artista (nombre, país, biografía, etc.).
Devuelve el Artist creado (201 Created).

- Endpoint: /api/artistas/eliminar/{id} (DELETE)

Elimina un artista según su ID.
Devuelve un HttpMessage con la confirmación.

- Endpoint: /api/artistas/actualizar/{id} (PUT)

Requiere un CreateOrUpdateArtistDTO con los datos actualizados.
Devuelve el Artist modificado.

## 💥 GenreController.cs

- Endpoint: /api/generos (GET)

Devuelve List<Genre> con todos los géneros musicales del sistema.

- Endpoint: /api/generos/{id} (GET)

Devuelve un Genre según su ID.

- Endpoint: /api/generos/crear (POST)

Requiere un CreateOrUpdateGenreDTO con los datos del nuevo género (nombre, descripción, etc.).
Devuelve el Genre creado.

- Endpoint: /api/generos/eliminar/{id} (DELETE)

Elimina el género identificado por su ID.
Devuelve un mensaje (HttpMessage) confirmando la eliminación.

- Endpoint: /api/generos/actualizar/{id} (PUT)

Requiere un CreateOrUpdateGenreDTO con los datos actualizados.
Devuelve el Genre actualizado.

## 🔒 AuthController.cs

- Endpoint: /api/auth/register (POST)

Requiere un RegisterDTO con los datos del nuevo usuario (nombre, email, contraseña, etc.).
Devuelve el User creado (201 Created).

- Endpoint: /api/auth/login (POST)

Requiere un LoginDTO con email y contraseña.
Devuelve un LoginResponseDTO con la información del usuario autenticado y, posiblemente, un token.

- Endpoint: /api/auth/logout (POST)

Requiere autenticación (token válido).
Cierra la sesión del usuario actual.
Devuelve 200 OK en caso de éxito.

- Endpoint: /api/auth/health (GET)

Solo accesible para usuarios autenticados.
Devuelve true como indicador de que la autenticación funciona.

- Endpoint: /api/auth/users (GET)

Requiere autenticación con roles MOD o ADMIN.
Devuelve List<UserWithoutPassDTO> con todos los usuarios registrados (sin contraseña).

# ![React-Logo](./public/react.svg) React + ![Vite](./public//vite.svg) Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) (or [oxc](https://oxc.rs) when used in [rolldown-vite](https://vite.dev/guide/rolldown)) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## React Compiler

The React Compiler is currently not compatible with SWC. See [this issue](https://github.com/vitejs/vite-plugin-react/issues/428) for tracking the progress.

## Expanding the ESLint configuration

If you are developing a production application, we recommend using TypeScript with type-aware lint rules enabled. Check out the [TS template](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts) for information on how to integrate TypeScript and [`typescript-eslint`](https://typescript-eslint.io) in your project.
