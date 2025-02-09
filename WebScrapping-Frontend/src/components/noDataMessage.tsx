import Button from '../components/button';

interface NoDataMessageProps {
  onScrap: () => void;
}

export const NoDataMessage = ({ onScrap }: NoDataMessageProps) => (
  <div className="flex flex-col items-center justify-center gap-4">
    <p className="text-3xl font-semibold">Nenhum dado encontrado!</p>
    <Button onClick={onScrap}>captura de alimentos</Button>
  </div>
);
