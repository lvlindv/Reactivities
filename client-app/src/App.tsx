import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  
  const [activities, setActivities] = useState([]);
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      // För att se vad som händer, .log(response)
      console.log(response);
      setActivities(response.data);
    })
    // Add a , and [] --> dependencies to not do an endless loop. ,[] (empty array) --> ensures that this only runs 1 time. 
  }, [])
    // ul = unordered list. loop over our unstored objects that are saved in setActivities.
    // {} lets us type javascript inside our react-component.
  return (
    <div>
      <Header as= 'h2' icon= 'users' content= 'Reactivities' />
          <List>
          {activities.map((activity: any) => (
              <List.Item key = {activity.id}>
              {activity.title}
              </List.Item>
            ))}
          </List>
    </div>
  );
}

export default App;
