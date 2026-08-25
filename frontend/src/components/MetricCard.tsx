import type { Metric } from "@/mocks/dashboard";

const toneStyles: Record<
  Metric["tone"],
  { card: string; icon: string }
> = {
  blue: {
    card: "bg-blue-50 border-blue-200",
    icon: "bg-blue-500",
  },

  red: {
    card: "bg-red-50 border-red-200",
    icon: "bg-red-500",
  },

  amber: {
    card: "bg-amber-50 border-amber-200",
    icon: "bg-amber-500",
  },

  green: {
    card: "bg-green-50 border-green-200",
    icon: "bg-green-500",
  },

  violet: {
    card: "bg-violet-50 border-violet-200",
    icon: "bg-violet-500",
  },
};

export function MetricCard({ metric }: { metric: Metric }) {
  const tone = toneStyles[metric.tone];

  return (
    <div
      className={`flex items-start justify-between gap-2 rounded-[11px] border px-4 py-3 shadow-[0_1px_2px_rgba(16,24,40,0.05)] ${tone.card}`}
    >
      <div className="min-w-0">
        <p className="text-[10px] font-medium text-slate-500">
          {metric.title}
        </p>

        <p className="mt-1 text-[26px] font-bold leading-none text-slate-900">
          {metric.value}
        </p>

        <p className="mt-2 truncate text-[9px] text-slate-500">
          {metric.caption}
        </p>
      </div>
    </div>
  );
}