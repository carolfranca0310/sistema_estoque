import { useState } from "react";
import { Button } from "@/components/Button";
import { Input } from "@/components/Input";
import { Select } from "@/components/Select";
import { exitTypeOptions, productOptions, lotOptions } from "@/data/stockExitOptions";

export const StockExit = () => {
  const [product, setProduct] = useState("");
  const [lot, setLot] = useState("");
  const [quantity, setQuantity] = useState("");
  const [exitDate, setExitDate] = useState("");

  const selectedLot = lotOptions.find((item) => item.value === lot);
  const availableQuantity = selectedLot?.availableQuantity ?? 0;
  const quantityNumber = Number(quantity);
  const hasInvalidQuantity =
    quantityNumber > 0 && quantityNumber > availableQuantity;

  return (
    <main className="min-h-screen bg-slate-50 px-8 py-8">
      <div className="mx-auto max-w-5xl">
        {/* Header */}
        <div className="mb-8">
          <h1 className="text-2xl font-semibold text-slate-900">
            Saída de estoque
          </h1>

          <p className="mt-1 text-sm text-slate-500">
            Registre produtos utilizados, perdidos ou retirados do estoque.
          </p>
        </div>

        <form className="space-y-6">
          {/* Dados da saída */}
          <section className="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
            <div className="mb-6">
              <h2 className="text-base font-semibold text-slate-900">
                Dados da saída
              </h2>

              <p className="mt-1 text-sm text-slate-500">
                Informe o produto, lote e quantidade que será retirada do
                estoque.
              </p>
            </div>

            <div className="grid grid-cols-1 gap-5 md:grid-cols-2">
              {/* Tipo de saída */}
              <Select
                label="Tipo de saída"
                placeholder="Selecione o tipo"
                options={exitTypeOptions}
                name="exitType"
                required
              />

              {/* Produto */}
              <Select
                label="Produto"
                placeholder="Selecione um produto"
                options={productOptions}
                name="product"
                value={product}
                onChange={setProduct}
                required
              />

              {/* Lote */}
              <div className="md:col-span-2">
                <Select
                  label="Lote"
                  placeholder={
                    product
                      ? "Selecione o lote utilizado"
                      : "Selecione primeiro um produto"
                  }
                  options={
                    product
                      ? lotOptions.filter(
                          (item) => item.productValue === product,
                        )
                      : []
                  }
                  name="lot"
                  value={lot}
                  onChange={setLot}
                  required
                  disabled={!product}
                />

                {selectedLot && (
                  <div className="mt-2 flex flex-wrap gap-x-4 gap-y-1 text-xs text-slate-400">
                    <span>
                      Disponível:{" "}
                      <strong className="font-medium text-slate-500">
                        {selectedLot.availableQuantity}{" "}
                        {selectedLot.unit}
                      </strong>
                    </span>

                    <span>
                      Valor unitário:{" "}
                      <strong className="font-medium text-slate-500">
                        {selectedLot.unitPrice}
                      </strong>
                    </span>

                    <span>
                      Validade:{" "}
                      <strong className="font-medium text-slate-500">
                        {selectedLot.expirationDate}
                      </strong>
                    </span>
                  </div>
                )}
              </div>

              {/* Quantidade */}
              <div>
                <Input
                  label="Quantidade"
                  type="number"
                  placeholder="Ex.: 4"
                  name="quantity"
                  value={quantity}
                  onChange={setQuantity}
                  required
                  disabled={!lot}
                />

                <p
                  className={`mt-1.5 text-xs ${
                    hasInvalidQuantity
                      ? "text-red-500"
                      : "text-slate-400"
                  }`}
                >
                  {hasInvalidQuantity
                    ? `Quantidade maior que o saldo disponível (${availableQuantity}).`
                    : selectedLot
                      ? `Saldo disponível: ${availableQuantity} ${selectedLot.unit}.`
                      : "Selecione um lote para informar a quantidade."}
                </p>
              </div>

              {/* Data */}
              <Input
                label="Data da saída"
                type="date"
                name="exitDate"
                value={exitDate}
                onChange={setExitDate}
                required
              />
            </div>
          </section>

          {/* Observação */}
          <section className="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
            <div className="mb-6">
              <h2 className="text-base font-semibold text-slate-900">
                Observação
              </h2>

              <p className="mt-1 text-sm text-slate-500">
                Adicione informações que ajudem a identificar o motivo da
                saída.
              </p>
            </div>

            <div>
              <label
                htmlFor="observation"
                className="mb-1.5 block text-sm font-medium text-slate-700"
              >
                Observação
              </label>

              <textarea
                id="observation"
                name="observation"
                rows={4}
                placeholder="Ex.: Produção de 50 dindins gourmet"
                className="w-full resize-none rounded-lg border border-slate-200 bg-white px-3 py-2.5 text-sm text-slate-900 outline-none transition placeholder:text-slate-400 focus:border-slate-400 focus:ring-2 focus:ring-slate-100"
              />

              <p className="mt-1.5 text-xs text-slate-400">
                Informe o contexto da movimentação quando necessário.
              </p>
            </div>
          </section>

          {/* Resumo */}
          {selectedLot && quantityNumber > 0 && !hasInvalidQuantity && (
            <section className="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
              <div className="mb-5">
                <h2 className="text-base font-semibold text-slate-900">
                  Resumo da saída
                </h2>

                <p className="mt-1 text-sm text-slate-500">
                  Confira os dados antes de registrar a movimentação.
                </p>
              </div>

              <div className="rounded-lg border border-slate-200 bg-slate-50 p-4">
                <div className="grid grid-cols-1 gap-4 sm:grid-cols-3">
                  <div>
                    <p className="text-xs text-slate-400">Lote</p>
                    <p className="mt-1 text-sm font-medium text-slate-700">
                      {selectedLot.label.split(" — ")[0]}
                    </p>
                  </div>

                  <div>
                    <p className="text-xs text-slate-400">
                      Quantidade retirada
                    </p>
                    <p className="mt-1 text-sm font-medium text-slate-700">
                      {quantityNumber} {selectedLot.unit}
                    </p>
                  </div>

                  <div>
                    <p className="text-xs text-slate-400">
                      Saldo após saída
                    </p>
                    <p className="mt-1 text-sm font-medium text-slate-700">
                      {availableQuantity - quantityNumber}{" "}
                      {selectedLot.unit}
                    </p>
                  </div>
                </div>
              </div>
            </section>
          )}

          {/* Ações */}
          <div className="flex items-center justify-end gap-3 pb-8">
            <Button variant="outline">Cancelar</Button>

            <Button
              type="submit"
              variant="filled"
              disabled={
                !product ||
                !lot ||
                !quantity ||
                quantityNumber <= 0 ||
                hasInvalidQuantity
              }
            >
              Registrar saída
            </Button>
          </div>
        </form>
      </div>
    </main>
  );
};