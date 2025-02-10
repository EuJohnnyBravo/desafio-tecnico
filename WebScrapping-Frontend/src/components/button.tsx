import React from 'react';

interface ButtonProps {
  onClick: () => void;
  children: React.ReactNode;
}

export default function Button({ onClick, children }: ButtonProps) {
  return (
    <button
      type="submit"
      className="min-w-28 rounded-full bg-orange-500 px-4 py-2 font-medium whitespace-nowrap text-white transition hover:bg-orange-600"
      onClick={onClick}
    >
      {children}
    </button>
  );
}
