import { Route, Switch } from "wouter";
import { Suspense, lazy } from "react";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
import SongsList from "./pages/SongsList";
import Navbar from "./components/Navbar";

const SongDetail = lazy(() => import("./pages/SongDetail"));
const AdminPanel = lazy(() => import("./pages/AdminPanel"));

export default function App() {
  return (
    <>
      <Navbar />
      <Suspense fallback={<div>Cargando...</div>}>
        <Switch>
          <Route path="/" component={Home} />
          <Route path="/login" component={Login} />
          <Route path="/register" component={Register} />
          <Route path="/songs" component={SongsList} />
          <Route path="/songs/:id" component={SongDetail} />
          <Route path="/admin" component={AdminPanel} />
        </Switch>
      </Suspense>
    </>
  );
}
