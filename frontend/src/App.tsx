import { Sidebar } from "./components/Sidebar";
import { Dashboard } from "./screens/Dashboard";


function App() {
  return (
    <div className="min-h-screen bg-slate-100">
      <Sidebar />

      <main className="ml-56 min-h-screen">
        <Dashboard />
      </main>
    </div>
  );
}

export default App;