import React, { Component } from 'react';
import {Card, Button, Form, Select, Divider, notification} from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios'

const FormItem = Form.Item
const Option = Select.Option

class Items extends Component {

    state = {
        categories: [],
        items: [],
        data: []
    }


    loadCategories = async ()=>{
        try{
            const response = await axios.get('/api/category')
            this.setState({
                categories: response.data.data
            })
        }catch(error){
            notification.error({ 
                message: "Error",
                description: "Erorr occured, please try again"})
        }
    }
    loadItems = async ()=>{
        try{
            const response = await axios.get('/api/item')
            this.setState({
                items: response.data.data
            })
        }catch(error){
            notification.error({ 
                message: "Error",
                description: "Erorr occured, please try again"})
        }
    }

    onSelect = (id)=>{
        const {items} = this.state
        const data = items.filter(i=>i.categoryId === id)
        this.setState({
            data: data
        })
    }
  componentWillMount = async () =>{
    await this.loadCategories();
    await this.loadItems();
  }


  render() {
      const {categories, data} = this.state
    return (
        <div>
            <br />
            <h3>
                Search items
            </h3>
            <Form>
                <FormItem label="Select category">
                    <Select onSelect={this.onSelect}>
                    {categories && categories.map(i=>{
                        return (<Option value={i.id} key={i.id}>{i.name}</Option>)
                    })}
                    </Select>
                </FormItem>
            </Form>
            <Divider/>
            {data && data.map(i=>{
                return (
                <div key={i.id}>
                <Card title={i.name} hoverable>
                    <p><b>Description</b> {i.description}</p>
                    <p><b>Price</b> {i.price}</p>
                    {i.itemValues && i.itemValues.map(j=>{
                        return (<p><b>{j.fieldDto.name}</b> {j.fieldValue}</p>)
                    })}
                </Card><br/></div>)
            })}

        </div>
    );
  }
}

export default Items;
