import { useState } from 'react';
import Button from '../../../components/button';

interface FormSearchProps {
  onSearch: (query: string) => void;
}

export default function FormSearch({ onSearch }: FormSearchProps) {
  const [query, setQuery] = useState('');

  const handleSearch = () => {
    onSearch(query);
  };

  return (
    <div className="mb-4">
      <div className="mb-4 flex flex-col">
        <label className="mb-1 block px-2 font-medium text-gray-700">
          Buscar um alimento
        </label>
        <input
          className="rounded-full border border-gray-300 px-4 py-2 focus:ring-1 focus:ring-orange-500 focus:outline-none"
          type="text"
          placeholder="Nome Completo ou parte dele"
          value={query}
          onChange={(e) => setQuery(e.target.value)}
        />
      </div>
      <Button onClick={handleSearch}>Buscar</Button>
    </div>
  );
}
