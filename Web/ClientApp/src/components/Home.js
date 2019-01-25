import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
    <h1>Hello, world!</h1>
    <p>This is test task for KMG Kumkol done by Tukhfatov Margulan.</p>
    <p>If you have any questions please write to me (tukhfatov.margulan@gmail.com).</p>
  </div>
);

export default connect()(Home);
