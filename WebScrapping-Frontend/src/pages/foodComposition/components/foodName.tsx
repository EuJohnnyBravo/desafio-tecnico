import { Food } from '../../../types/foods';

export default function FoodName({ food }: { food: Food | null }) {
  return (
    <div>
      <h1 className="text-xl font-bold">
        <span className="text-orange-500">{food?.code}: </span> {food?.name}
      </h1>
      <div className="flex flex-col">
        <p className="font-semibold">
          <span className="text-orange-500">Nome Ciêntifico: </span>
          {food?.scientificName}
        </p>
        <p className="font-semibold">
          <span className="text-orange-500">Grupo: </span>
          {food?.group}
        </p>
      </div>
    </div>
  );
}
