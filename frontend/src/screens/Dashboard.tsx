import { MetricCard } from "@/components/MetricCard";
import { LowStockCard } from "@/components/LowStockCard";
import { metrics } from "@/mocks/dashboard";
import { ExpiringLotsCard } from "@/components/ExpiringLotsCard";

export function Dashboard() {
  return (
    <main className="flex-1 overflow-y-auto bg-slate-50 p-8">
      <h1 className="text-[28px] font-bold leading-none tracking-tight text-slate-900">
        Dashboard
      </h1>

      <p className="mt-2 text-[12px] text-slate-500">
        Visão geral do sistema de gestão
      </p>

      <div className="mt-5 grid grid-cols-1 gap-4 sm:grid-cols-2 xl:grid-cols-4">
        {metrics.map((metric) => (
          <MetricCard key={metric.title} metric={metric} />
        ))}
      </div>

      <div className="mt-5 grid grid-cols-1 gap-4 lg:grid-cols-2">
        <LowStockCard />
        <ExpiringLotsCard />
      </div>
    </main>
  );
}