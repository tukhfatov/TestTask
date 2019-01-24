﻿import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Category from './components/Category';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/category' component={Category} />
  </Layout>
);
