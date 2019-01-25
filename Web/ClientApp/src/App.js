import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Category from './components/Category';
import AddItem from './components/AddItem';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/category' component={Category} />
    <Route path='/item/add' component={AddItem} />
  </Layout>
);
