import { useEffect, useState } from 'react';

function App() {
  const [weather, setWeather] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5082/weatherforecast')
        .then((res) => res.json())
        .then((data) => setWeather(data))
        .catch((err) => console.error('Błąd:', err));
  }, []);

  return (
      <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
        <h1>Połączenie React + C# Web API działa!</h1>
        <pre>{JSON.stringify(weather, null, 2)}</pre>
      </div>
  );
}

export default App;