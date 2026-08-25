interface ButtonProps {
  children: React.ReactNode;
  type?: "button" | "submit" | "reset";
  variant?: "filled" | "outline";
  disabled?: boolean;
  onClick?: () => void;
}

export const Button = ({
  children,
  type = "button",
  variant = "filled",
  disabled = false,
  onClick,
}: ButtonProps) => {
  const baseStyles =
    "rounded-lg px-5 py-2.5 text-sm font-medium transition disabled:cursor-not-allowed disabled:opacity-50";

  const variants = {
    filled:
      "bg-slate-900 text-white hover:bg-slate-800",
    outline:
      "border border-slate-300 bg-white text-slate-700 hover:bg-slate-50",
  };

  return (
    <button
      type={type}
      disabled={disabled}
      onClick={onClick}
      className={`${baseStyles} ${variants[variant]}`}
    >
      {children}
    </button>
  );
};