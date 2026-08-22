import type { LowStockItem as LowStockItemType } from "@/mocks/dashboard";

interface LowStockItemProps {
  item: LowStockItemType;
}

export const LowStockItem = ({ item }: LowStockItemProps) => {
  return (
    <div className="flex items-center justify-between rounded-lg border border-slate-200 bg-slate-50 px-3 py-2">
      <div className="min-w-0">
        <p className="truncate text-xs font-medium text-slate-800">
          {item.name}
        </p>

        <p className="mt-0.5 text-[10px] text-slate-500">
          Lote: {item.code}
        </p>
      </div>

      <div className="ml-3 shrink-0 text-right">
        <p className="text-xs font-semibold text-red-600">
          {item.currentStock} {item.unit}
        </p>

        <p className="text-[9px] text-slate-400">
          Mín: {item.minimumStock}
        </p>
      </div>
    </div>
  );
}