import React from 'react';

function ProblemList({ problems, onDelete }) {
    return (
        <div>
            <h2>Список проблем</h2>
            {problems.map(problem => (
                <div key={problem.id} style={{ border: '1px solid #ddd', margin: '10px', padding: '10px' }}>
                    <h3>{problem.title}</h3>
                    <p>{problem.description}</p>
                    <button onClick={() => onDelete(problem.id)}>Удалить</button>
                </div>
            ))}
        </div>
    );
}

export default ProblemList;