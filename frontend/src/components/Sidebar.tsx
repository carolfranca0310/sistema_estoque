import { NavLink } from "react-router-dom";

const navItems = [
  {
    label: "Dashboard",
    path: "/dashboard",
  },
  {
    label: "Entradas",
    path: "/entradas",
  },
  {
    label: "Saídas",
    path: "/saidas",
  },
];

export const Sidebar = () => {
  return (
    <aside className="fixed inset-y-0 left-0 z-50 flex w-56 flex-col bg-slate-800 text-slate-300">
      {/* Logo */}
      <div className="border-b border-white/10 px-4 py-5">
        <div className="flex items-center gap-3">
          <div className="flex h-9 w-9 items-center justify-center rounded-lg bg-white/10">
          </div>

          <div>
            <p className="text-sm font-semibold leading-tight text-white">
              Stock
            </p>

            <p className="mt-1 text-xs text-slate-400">
              Sistema de Gestão
            </p>
          </div>
        </div>
      </div>

      {/* Menu */}
      <nav className="flex-1 px-3 py-5">
        <p className="mb-3 px-2 text-[10px] font-semibold uppercase tracking-wider text-slate-500">
          Menu principal
        </p>

        <ul className="space-y-1">
          {navItems.map((item) => (
            <li key={item.label}>
              <NavLink
                to={item.path}
                className={({ isActive }) =>
                  `flex w-full items-center gap-3 rounded-lg px-3 py-2.5 text-sm transition-colors ${
                    isActive
                      ? "bg-white text-slate-800"
                      : "text-slate-300 hover:bg-white/10 hover:text-white"
                  }`
                }
              >
                <span>{item.label}</span>
              </NavLink>
            </li>
          ))}
        </ul>

        {/* <ul className="space-y-1">
          {navItems.map((item) => {
            return (
              <li key={item.label}>
                <button
                  type="button"
                  className={`flex w-full items-center gap-3 rounded-lg px-3 py-2.5 text-sm transition-colors ${
                    item.active
                      ? "bg-white text-slate-800"
                      : "text-slate-300 hover:bg-white/10 hover:text-white"
                  }`}
                >
                  <span>{item.label}</span>
                </button>
              </li>
            );
          })}
        </ul> */}
      </nav>

      {/* Usuário */}
      <div className="border-t border-white/10 p-4">
        <div className="flex items-center gap-3">
          <div className="flex h-9 w-9 shrink-0 items-center justify-center rounded-full bg-white/10 text-xs font-semibold text-white">
            RH
          </div>

          <div className="min-w-0 flex-1">
            <p className="truncate text-sm font-medium text-white">
              Usuário
            </p>

            <p className="text-xs text-slate-400">
              Administrador
            </p>
          </div>
        </div>

        <button
          type="button"
          className="mt-4 flex w-full items-center gap-3 rounded-lg px-2 py-2 text-sm text-slate-400 transition-colors hover:bg-white/10 hover:text-white"
        >
          <span>Sair</span>
        </button>
      </div>
    </aside>
  );
}