import { Composition } from '../../../types/foodComposition';

export default function CompositionTable({
  compositions,
}: {
  compositions: Composition[];
}) {
  return (
    <div className="rounded-box border-base-content/5 bg-base-100 overflow-x-auto border">
      <table className="table">
        <thead>
          <tr>
            <th>Componente</th>
            <th>Unidade</th>
            <th>Valor por 100g</th>
            <th>Desvio padrão</th>
            <th>Valor Mínimo</th>
            <th>Valor Máximo</th>
            <th>Número de dados ulitilizados</th>
            <th>Referência</th>
            <th>Tipo de dados</th>
          </tr>
        </thead>
        <tbody>
          {compositions.map((composition, index) => (
            <tr
              key={`${composition.foodCode}-${index}`}
              className="hover:bg-base-content/5 cursor-pointer"
            >
              <th>{composition.component}</th>
              <td>{composition.unit}</td>
              <td>{composition.valuePer100g}</td>
              <td>{composition.standardDeviation}</td>
              <td>{composition.minimumValue}</td>
              <td>{composition.maximumValue}</td>
              <td>{composition.numberOfDataUsed}</td>
              <td>{composition.reference}</td>
              <td>{composition.dataType}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
