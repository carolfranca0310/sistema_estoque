import { Button } from "@/components/Button";
import { Input } from "@/components/Input";
import { Select } from "@/components/Select";
import { categoryOptions } from "@/data/productOptions";
import { unitOptions } from "@/data/unitOptions";
import { useState } from "react";

export const ProductRegistration = () => {
  const [productName, setProductName] = useState("");
  const [category, setCategory] = useState("");
  const [weight, setWeight] = useState("");
  const [unit, setUnit] = useState("");
  const [minimumStockLevel, setMinimumStockLevel] = useState("");
  const [datePurchase, setDatePurchase] = useState("");
  const [expirationDate, setExpirationDate] = useState("");
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

  const today = new Date().toISOString().split("T")[0];

  // Validações
  const hasInvalidProductName = productName.trim() === "";
  const hasInvalidCategory = category === "";
  const hasInvalidWeight =
    weight === "" || Number(weight) < 0;
  const hasInvalidUnit = unit === "";
  const hasInvalidMinimumStock =
    minimumStockLevel === "" || Number(minimumStockLevel) < 0;
  const hasInvalidPurchaseDate = datePurchase === "";
  const hasInvalidExpirationDate =
    expirationDate === "" || expirationDate < today;
  const hasInvalidQuantity =
    quantity === "" || Number(quantity) < 1;
  const hasInvalidUnitPrice =
    unitPrice === "" || Number(unitPrice) < 0;

  const isFormValid =
    !hasInvalidProductName &&
    !hasInvalidCategory &&
    !hasInvalidWeight &&
    !hasInvalidUnit &&
    !hasInvalidMinimumStock &&
    !hasInvalidPurchaseDate &&
    !hasInvalidExpirationDate &&
    !hasInvalidQuantity &&
    !hasInvalidUnitPrice;

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
              <div className="md:col-span-2">
                <Input
                  label="Nome do produto"
                  placeholder="Ex.: Creme de leite"
                  name="name"
                  value={productName}
                  onChange={setProductName}
                  required
                />

                {hasInvalidProductName && (
                  <p className="mt-1.5 text-xs text-red-500">
                    Informe o nome do produto.
                  </p>
                )}
              </div>

              {/* Marca */}
              <Input
                label="Marca"
                placeholder="Ex.: Itambé"
                name="brand"
              />

              {/* Categoria */}
              <div>
                <Select
                  label="Categoria"
                  placeholder="Selecione uma categoria"
                  options={categoryOptions}
                  name="category"
                  value={category}
                  onChange={setCategory}
                  required
                />

                {hasInvalidCategory && (
                  <p className="mt-1.5 text-xs text-red-500">
                    Selecione uma categoria.
                  </p>
                )}
              </div>

              {/* Peso */}
              <div>
                <Input
                  label="Peso"
                  type="number"
                  min="0"
                  placeholder="Ex.: 250"
                  name="weight"
                  value={weight}
                  onChange={setWeight}
                  required
                />

                {hasInvalidWeight && (
                  <p className="mt-1.5 text-xs text-red-500">
                    {weight === ""
                      ? "Informe o peso."
                      : "O peso não pode ser menor que zero."}
                  </p>
                )}

                <p className="mt-1.5 text-xs text-slate-400">
                  Peso utilizado como parte da identificação do item.
                </p>
              </div>

              {/* Unidade de medida */}
              <div>
                <Select
                  label="Unidade de medida"
                  placeholder="Selecione uma unidade"
                  options={unitOptions}
                  name="unit"
                  value={unit}
                  onChange={setUnit}
                  required
                />

                {hasInvalidUnit && (
                  <p className="mt-1.5 text-xs text-red-500">
                    Selecione uma unidade de medida.
                  </p>
                )}
              </div>

              {/* Estoque mínimo */}
              <div>
                <Input
                  label="Estoque mínimo"
                  type="number"
                  min="0"
                  placeholder="Ex.: 15"
                  name="minimumStock"
                  value={minimumStockLevel}
                  onChange={setMinimumStockLevel}
                  required
                />

                {hasInvalidMinimumStock && (
                  <p className="mt-1.5 text-xs text-red-500">
                    {minimumStockLevel === ""
                      ? "Informe o estoque mínimo."
                      : "O estoque mínimo não pode ser menor que zero."}
                  </p>
                )}
              </div>
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
              <div>
                <Input
                  label="Data de compra"
                  type="date"
                  name="purchaseDate"
                  value={datePurchase}
                  onChange={setDatePurchase}
                  required
                />

                {hasInvalidPurchaseDate && (
                  <p className="mt-1.5 text-xs text-red-500">
                    Informe a data de compra.
                  </p>
                )}
              </div>

              {/* Data de validade */}
              <div>
                <Input
                  label="Data de validade"
                  type="date"
                  name="expirationDate"
                  value={expirationDate}
                  onChange={setExpirationDate}
                  required
                  min={today}
                />

                {hasInvalidExpirationDate && (
                  <p className="mt-1.5 text-xs text-red-500">
                    {expirationDate === ""
                      ? "Informe a data de validade."
                      : "A data de validade não pode ser anterior a hoje."}
                  </p>
                )}
              </div>

              {/* Quantidade */}
              <div>
                <Input
                  label="Quantidade"
                  type="number"
                  min="1"
                  placeholder="Ex.: 20"
                  name="amount"
                  value={quantity}
                  onChange={setQuantity}
                  required
                />

                {hasInvalidQuantity && (
                  <p className="mt-1.5 text-xs text-red-500">
                    {quantity === ""
                      ? "Informe a quantidade."
                      : "A quantidade não pode ser menor que um."}
                  </p>
                )}

                <p className="mt-1.5 text-xs text-slate-400">
                  Quantidade de itens recebidos neste lote.
                </p>
              </div>

              {/* Preço unitário */}
              <div>
                <Input
                  label="Preço unitário"
                  type="number"
                  step="0.01"
                  min="0"
                  placeholder="Ex.: 5,42"
                  name="unitPrice"
                  value={unitPrice}
                  onChange={setUnitPrice}
                  required
                />

                {hasInvalidUnitPrice && (
                  <p className="mt-1.5 text-xs text-red-500">
                    {unitPrice === ""
                      ? "Informe o preço unitário."
                      : "O preço unitário não pode ser menor que zero."}
                  </p>
                )}

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
            <Button
              type="button"
              variant="outline"
            >
              Cancelar
            </Button>

            <Button
              type="submit"
              variant="filled"
              disabled={!isFormValid}
            >
              Registrar entrada
            </Button>
          </div>
        </form>
      </div>
    </main>
  );
};