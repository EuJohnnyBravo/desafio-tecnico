import { useNavigate } from 'react-router';
import { Food } from '../../../types/foods';

export default function FoodsTable({ foods }: { foods: Food[] }) {
  const navigate = useNavigate();

  return (
    <div className="rounded-box border-base-content/5 bg-base-100 overflow-x-auto border">
      <table className="table">
        <thead>
          <tr>
            <th></th>
            <th>Nome</th>
            <th>Nome ciêntifico</th>
            <th>Grupo</th>
          </tr>
        </thead>
        <tbody>
          {foods.map((food) => (
            <tr
              key={food.code}
              className="hover:bg-base-content/5 cursor-pointer"
              onClick={() => {
                navigate(`/food/${food.code}`);
                console.log(food.code);
              }}
            >
              <th className="text-orange-500">{food.code}</th>
              <td>{food.name}</td>
              <td>{food.scientificName}</td>
              <td>{food.group}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
