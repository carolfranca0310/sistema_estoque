export type MetricTone = "blue" | "red" | "amber" | "green" | "violet";

export interface Metric {
  title: string;
  value: string;
  caption: string;
  tone: MetricTone;
}

export const metrics: Metric[] = [
  {
    title: "Total de Itens",
    value: "42",
    caption: "Ingredientes e materiais cadastrados",
    tone: "blue",
  },
  {
    title: "Estoque em Baixa",
    value: "6",
    caption: "Itens abaixo do estoque mínimo",
    tone: "red",
  },
  {
    title: "Vencendo",
    value: "4",
    caption: "Itens próximos do vencimento",
    tone: "amber",
  },
  {
    title: "Lista de Compras",
    value: "8",
    caption: "Itens para próxima reposição",
    tone: "green",
  },
];

export interface LowStockItem {
  code: string;
  name: string;
  currentStock: number;
  minimumStock: number;
  unit: string;
}

export const lowStockItems: LowStockItem[] = [
  {
    code: "ING-001",
    name: "Leite condensado",
    currentStock: 4,
    minimumStock: 10,
    unit: "un",
  },
  {
    code: "ING-002",
    name: "Creme de leite",
    currentStock: 3,
    minimumStock: 8,
    unit: "un",
  },
  {
    code: "ING-003",
    name: "Chocolate em pó 50%",
    currentStock: 350,
    minimumStock: 1000,
    unit: "g",
  },
  {
    code: "ING-004",
    name: "Morango",
    currentStock: 1,
    minimumStock: 3,
    unit: "kg",
  },
  {
    code: "MAT-001",
    name: "Pote 250ml com tampa",
    currentStock: 18,
    minimumStock: 50,
    unit: "un",
  },
  {
    code: "MAT-002",
    name: "Colher descartável",
    currentStock: 25,
    minimumStock: 100,
    unit: "un",
  },
];

export interface ExpiringLot {
  code: string;
  name: string;
  expirationDate: string;
  daysUntilExpiration: number;
}

export const expiringLots: ExpiringLot[] = [
  {
    code: "ING-003",
    name: "Chocolate em pó 50%",
    expirationDate: "23/11/2026",
    daysUntilExpiration: 93,
  },
  {
    code: "ING-007",
    name: "Leite em pó integral",
    expirationDate: "15/12/2026",
    daysUntilExpiration: 115,
  },
  {
    code: "ING-011",
    name: "Granulado de chocolate",
    expirationDate: "08/01/2027",
    daysUntilExpiration: 139,
  },
  {
    code: "ING-014",
    name: "Coco ralado",
    expirationDate: "21/02/2027",
    daysUntilExpiration: 183,
  },
];