import { useEffect, useState } from 'react';
import Header from '../../components/header';
import CompositionTable from './components/compositionTable';
import { Food } from '../../types/foods';
import { Composition } from '../../types/foodComposition';
import { useParams } from 'react-router';
import {
  getFoodByCode,
  getFoodComposition,
  postFoodComposition,
} from '../../api/request';
import { LoadingIndicator } from '../../components/loadingIndicator';
import { ErrorMessage } from '../../components/errorMessage';
import { NoDataMessage } from '../../components/noDataMessage';
import FoodName from './components/foodName';

export default function FoodComposition() {
  const [food, setFood] = useState<Food | null>(null);
  const [compositions, setCompositions] = useState<Composition[]>([]);
  const [scrapping, setScrapping] = useState(false);
  const [error, setError] = useState(false);
  const [noData, setNoData] = useState(false);
  const { code } = useParams<{ code: string }>();

  const fetchData = async (code: string) => {
    try {
      const foodData = await getFoodByCode(code);
      setFood(foodData);
      const compositionData = await getFoodComposition(code);
      if (compositionData.length === 0) {
        setNoData(true);
      } else {
        setCompositions(compositionData);
        setNoData(false);
      }
    } catch (error) {
      console.error('Erro ao buscar dados:', error);
      setError(true);
    }
  };

  useEffect(() => {
    if (code) {
      fetchData(code);
    } else {
      setNoData(true);
    }
  }, [code]);

  if (!code) {
    return null;
  }

  const handleScrap = async () => {
    setScrapping(true);
    setNoData(false);
    await postFoodComposition(code);
    await fetchData(code);
    setScrapping(false);
  };

  return (
    <>
      <Header />
      <div className="mx-auto my-4 max-w-7xl rounded-lg bg-white p-6 shadow-md">
        {!error && <FoodName food={food} />}
        {scrapping && <LoadingIndicator />}
        {error && <ErrorMessage />}
        {noData && !error && (
          <NoDataMessage onScrap={handleScrap} foodCode={food?.code} />
        )}
        {compositions.length > 0 && !error && (
          <CompositionTable compositions={compositions} />
        )}
      </div>
    </>
  );
}
