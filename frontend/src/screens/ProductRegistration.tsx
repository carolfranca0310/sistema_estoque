import { Button } from "@/components/Button";
import { Input } from "@/components/Input";
import { Select } from "@/components/Select";
import { categoryOptions } from "@/data/productOptions";
import { unitOptions } from "@/data/unitOptions";
import { useState } from "react";

export const ProductRegistration = () => {
  const [quantity, setQuantity] = useState("");
  const [unitPrice, setUnitPrice] = useState("");

  const totalPrice =
    Number(quantity) > 0 && Number(unitPrice) > 0
      ? Number(quantity) * Number(unitPrice)
      : 0;

  const formatCurrency = (value: number) => {
    return value.toLocaleString("pt-BR", {
      style: "currency",
      currency: "BRL",
    });
  };

  return (
    <main className="min-h-screen bg-slate-50 px-8 py-8">
      <div className="mx-auto max-w-5xl">
        {/* Header */}
        <div className="mb-8">
          <h1 className="text-2xl font-semibold text-slate-900">
            Entrada de Produto
          </h1>

          <p className="mt-1 text-sm text-slate-500">
            Cadastre o produto e registre uma nova entrada no estoque.
          </p>
        </div>

        <form className="space-y-6">
          {/* Dados do produto */}
          <section className="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
            <div className="mb-6">
              <h2 className="text-base font-semibold text-slate-900">
                Dados do produto
              </h2>

              <p className="mt-1 text-sm text-slate-500">
                Informações cadastrais utilizadas para identificar e controlar
                o produto.
              </p>
            </div>

            <div className="grid grid-cols-1 gap-5 md:grid-cols-2">
              {/* Nome */}
              <Input
                label="Nome do produto"
                placeholder="Ex.: Arroz branco"
                name="name"
                required
                className="md:col-span-2"
              />

              {/* Marca */}
              <Input
                label="Marca"
                placeholder="Ex.: Camil"
                name="brand"
              />

              {/* Categoria */}
              <Select
                label="Categoria"
                placeholder="Selecione uma categoria"
                options={categoryOptions}
                name="category"
                required
              />

              {/* Peso */}
              <div>
                <Input
                  label="Peso"
                  type="number"
                  placeholder="Ex.: 1"
                  name="weight"
                />
                
                <p className="mt-1.5 text-xs text-slate-400">
                  Peso utilizado como parte da identificação do item.
                </p>
              </div>

              {/* Unidade de medida */}
              <Select
                label="Unidade de medida"
                placeholder="Selecione uma unidade"
                options={unitOptions}
                name="unit"
                required
              />

              {/* Estoque mínimo */}
              <Input
                label="Estoque mínimo"
                type="number"
                placeholder="Ex.: 20"
                name="minimumStock"
              />
            </div>
          </section>

          {/* Dados da entrada / lote */}
          <section className="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
            <div className="mb-6">
              <h2 className="text-base font-semibold text-slate-900">
                Dados da entrada
              </h2>

              <p className="mt-1 text-sm text-slate-500">
                Informações específicas deste lote de produto.
              </p>
            </div>

            <div className="grid grid-cols-1 gap-5 md:grid-cols-2">
              {/* Data de compra */}
              <Input
                label="Data de compra"
                type="date"
                name="purchaseDate"
              />

              {/* Data de validade */}
              <Input
                label="Data de validade"
                type="date"
                name="expirationDate"
              />

              {/* Quantidade */}
              <div>
                <Input
                  label="Quantidade"
                  type="number"
                  placeholder="Ex.: 20"
                  name="amount"
                  value={quantity}
                  onChange={setQuantity}
                />

                <p className="mt-1.5 text-xs text-slate-400">
                  Quantidade de itens recebidos neste lote.
                </p>
              </div>

              {/* Preço unitário */}
              <div>
                <Input
                  label="Preço unitário"
                  type="number"
                  placeholder="R$ 5,42"
                  name="unitPrice"
                  value={unitPrice}
                  onChange={setUnitPrice}
                />

                <p className="mt-1.5 text-xs text-slate-400">
                  Valor unitário praticado na compra deste lote.
                </p>
              </div>
            </div>

            {/* Preço total */}
            <div className="mt-6 rounded-lg border border-slate-200 bg-slate-50 p-4">
              <div className="flex items-center justify-between">
                <div>
                  <p className="text-sm font-medium text-slate-700">
                    Preço total
                  </p>

                  <p className="mt-1 text-xs text-slate-400">
                    Calculado automaticamente pela quantidade × preço unitário.
                  </p>
                </div>

                <span className="text-lg font-semibold text-slate-900">
                  {formatCurrency(totalPrice)}
                </span>
              </div>
            </div>
          </section>

          {/* Ações */}
          <div className="flex items-center justify-end gap-3 pb-8">
            <Button variant="outline">
              Cancelar
            </Button>

            <Button type="submit" variant="filled">
              Registrar entrada
            </Button>
          </div>
        </form>
      </div>
    </main>
  );
};