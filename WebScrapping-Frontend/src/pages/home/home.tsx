import { useEffect, useState } from 'react';
import { getFoods, postFoods } from '../../api/request';
import Header from '../../components/header';
import FormSearch from './components/formSearch';
import { Food } from '../../types/foods';
import FoodsTable from './components/foodsTable';
import { NoDataMessage } from '../../components/noDataMessage';
import { ErrorMessage } from '../../components/errorMessage';
import { LoadingIndicator } from '../../components/loadingIndicator';

export default function Home() {
  const [scrapping, setScrapping] = useState(false);
  const [error, setError] = useState(false);
  const [noData, setNoData] = useState(false);
  const [foods, setFoods] = useState<Food[]>([]);
  const [allFoods, setAllFoods] = useState<Food[]>([]);

  const fetchFoods = async () => {
    try {
      const foodsData = await getFoods();
      if (foodsData.length === 0) {
        setNoData(true);
      } else {
        setFoods(foodsData);
        setAllFoods(foodsData);
        setNoData(false);
      }
    } catch {
      setError(true);
    }
  };

  useEffect(() => {
    fetchFoods();
  }, []);

  const handleScrap = async () => {
    setScrapping(true);
    setNoData(false);
    await postFoods();
    await fetchFoods();
    setScrapping(false);
  };

  const handleSearch = (query: string) => {
    if (query === '') {
      setFoods(allFoods);
      setNoData(false);
    } else {
      const filteredFoods = allFoods.filter((food) =>
        food.name.toLowerCase().includes(query.toLowerCase()),
      );
      if (filteredFoods.length === 0) {
        setFoods([]); // Clear the table when no results are found
        setNoData(true);
      } else {
        setFoods(filteredFoods);
        setNoData(false);
      }
    }
  };

  return (
    <>
      <Header />
      <div className="mx-auto my-4 max-w-7xl rounded-lg bg-white p-6 shadow-md">
        <FormSearch onSearch={handleSearch} />
        <div>
          {scrapping && <LoadingIndicator />}
          {error && <ErrorMessage />}
          {noData && !error && <NoDataMessage onScrap={handleScrap} />}
          {foods.length > 0 && !error && <FoodsTable foods={foods} />}
        </div>
      </div>
    </>
  );
}
