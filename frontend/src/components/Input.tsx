interface InputProps {
  label: string;
  type?: string;
  placeholder?: string;
  value?: string;
  name?: string;
  required?: boolean;
  disabled?: boolean;
  min?: string;
  step?: string;
  onChange?: (value: string) => void;
  className?: string;
}

export const Input = ({
  label,
  type = "text",
  placeholder,
  value = "",
  name,
  required = false,
  disabled = false,
  min,
  step,
  onChange,
  className = "",
}: InputProps) => {
  return (
    <div className={className}>
      <label className="mb-2 block text-sm font-medium text-slate-700">
        {label}

        {required && <span className="ml-1 text-red-500">*</span>}
      </label>

      <input
        type={type}
        name={name}
        value={value}
        required={required}
        disabled={disabled}
        min={min}
        step={step}
        placeholder={placeholder}
        onChange={(event) => onChange?.(event.target.value)}
        className="w-full rounded-lg border border-slate-300 px-3 py-2.5 text-sm text-slate-700 outline-none transition placeholder:text-slate-400 focus:border-slate-500 focus:ring-2 focus:ring-slate-200 disabled:cursor-not-allowed disabled:bg-slate-100 disabled:text-slate-400"
      />
    </div>
  );
};