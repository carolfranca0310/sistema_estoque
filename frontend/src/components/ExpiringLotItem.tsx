import type { ExpiringLot } from "@/mocks/dashboard";

interface ExpiringLotItemProps {
  lot: ExpiringLot;
}

export function ExpiringLotItem({ lot }: ExpiringLotItemProps) {
  return (
    <div className="rounded-lg border border-amber-200 bg-amber-50 px-3 py-2.5">
      <p className="truncate text-[11px] font-semibold text-slate-900">
        {lot.name}
      </p>

      <p className="mt-1 text-[10px] text-slate-500">
        Lote: <span className="font-medium text-slate-700">{lot.code}</span>
      </p>

      <p className="mt-1 text-[10px] text-slate-500">
        Vence em:{" "}
        <span className="font-medium text-amber-700">
          {formatExpiration(lot.daysUntilExpiration)}
        </span>
      </p>

      <p className="mt-0.5 text-[9px] text-slate-400">
        {lot.expirationDate}
      </p>
    </div>
  );
}

function formatExpiration(days: number) {
  const months = Math.floor(days / 30);

  if (months === 0) {
    return `${days} dias`;
  }

  return `${months} ${months === 1 ? "mês" : "meses"} (${days} dias)`;
}