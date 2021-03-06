﻿import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
  <Navbar inverse fixedTop fluid collapseOnSelect>
    <Navbar.Header>
      <Navbar.Brand>
        <Link to={'/'}>Web</Link>
      </Navbar.Brand>
      <Navbar.Toggle />
    </Navbar.Header>
    <Navbar.Collapse>
      <Nav>
        <LinkContainer to={'/'} exact>
          <NavItem>
            <Glyphicon glyph='home' /> Home
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/category'}>
          <NavItem>
            <Glyphicon glyph='th-list' /> Category
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/itemadd'}>
          <NavItem>
            <Glyphicon glyph='plus' /> Add Item
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/item'}>
          <NavItem>
            <Glyphicon glyph='search' /> Items
          </NavItem>
        </LinkContainer>
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);
