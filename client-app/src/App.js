import React, { useState, useEffect } from 'react';
import axios from 'axios';

function App() {
  const [data, setData] = useState(null);

  useEffect(() => {
    axios.get('/api/Problem')
        .then(response => {
          setData(response.data);
        })
        .catch(error => console.error('Error fetching data:', error));
  }, []);

  return (
      <div className="App">
        <h1>My ASP.NET Core + React App</h1>
        {data ? (
            <pre>{JSON.stringify(data, null, 2)}</pre>
        ) : (
            <p>Loading...</p>
        )}
      </div>
  );
}

export default App;