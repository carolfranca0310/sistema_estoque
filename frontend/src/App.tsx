import { Navigate, Route, Routes } from "react-router-dom";
import { Sidebar } from "./components/Sidebar";
import { Dashboard } from "./screens/Dashboard";
import { ProductRegistration } from "./screens/ProductRegistration";
import { StockExit } from "./screens/StockExit";

function App() {
  return (
    <div className="min-h-screen bg-slate-100">
      <Sidebar />

      <main className="ml-56">
        <Routes>
          <Route path="/" element={<Navigate to="/dashboard" replace />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/entradas" element={<ProductRegistration />} />
          <Route path="/saidas" element={<StockExit />} />
        </Routes>
      </main>
    </div>
  );
}

export default App;