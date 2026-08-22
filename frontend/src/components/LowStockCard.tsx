import { lowStockItems } from "@/mocks/dashboard";
import { LowStockItem } from "./LowStockItem";

export function LowStockCard() {
  return (
    <section className="flex flex-col rounded-xl border border-slate-200 bg-white shadow-sm">
      <div className="px-4 pb-3 pt-4">
        <h2 className="text-[13px] font-semibold text-slate-900">
          Estoque Baixo
        </h2>

        <p className="mt-1 text-[10px] text-slate-500">
          Itens que precisam de reposição urgente
        </p>
      </div>

      <div className="border-t border-slate-200" />

      <div className="max-h-[300px] overflow-y-auto p-4">
        <div className="flex flex-col gap-2">
          {lowStockItems.map((item) => (
            <LowStockItem key={item.code} item={item} />
          ))}
        </div>
      </div>
    </section>
  );
}