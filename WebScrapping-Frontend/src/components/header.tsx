export default function Header() {
  return (
    <div className="relative h-[300px] w-full bg-[url('./assets/banner.jpg')] bg-cover bg-center text-white md:h-[400px] lg:h-[450px]">
      <div className="absolute top-0 left-0 flex w-full items-center justify-center bg-black/50 px-6 py-3">
        <div className="text-sm font-semibold">TBCA</div>
      </div>
      <div className="flex h-full items-center justify-center bg-black/40">
        <h1 className="text-center text-2xl font-bold md:text-4xl">
          Composição Química <br />
          <span className="text-2xl md:text-2xl">(Informação Estatística)</span>
        </h1>
      </div>
    </div>
  );
}
