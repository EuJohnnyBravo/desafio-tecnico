import Button from '../components/button';

interface NoDataMessageProps {
  onScrap: () => void;
  foodCode?: string;
}

export const NoDataMessage = ({ onScrap, foodCode }: NoDataMessageProps) => (
  <div className="flex flex-col items-center justify-center gap-4 py-4">
    {foodCode && (
      <p className="text-2xl font-semibold">
        Nenhum dado encontrado para o código{' '}
        <span className="text-orange-500">{foodCode}</span>!
      </p>
    )}
    {!foodCode && (
      <p className="text-2xl font-semibold">Nenhum dado encontrado!</p>
    )}
    <Button onClick={onScrap}>captura de alimentos</Button>
  </div>
);
