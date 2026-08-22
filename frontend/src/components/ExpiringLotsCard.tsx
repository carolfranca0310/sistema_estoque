import { expiringLots } from "@/mocks/dashboard";
import { ExpiringLotItem } from "./ExpiringLotItem";

export function ExpiringLotsCard() {
  return (
    <section className="flex flex-col rounded-xl border border-slate-200 bg-white shadow-sm">
      <div className="px-4 pb-3 pt-4">
        <h2 className="text-[13px] font-semibold text-slate-900">
          Vencimentos Próximos
        </h2>

        <p className="mt-1 text-[10px] text-slate-500">
          Lotes que vencem nos próximos 6 meses
        </p>
      </div>

      <div className="border-t border-slate-200" />

      <div className="max-h-[300px] overflow-y-auto p-4">
        <div className="flex flex-col gap-2">
          {expiringLots.map((lot) => (
            <ExpiringLotItem key={lot.code} lot={lot} />
          ))}
        </div>
      </div>
    </section>
  );
}