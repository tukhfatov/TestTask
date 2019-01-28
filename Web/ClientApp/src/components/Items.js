import React, { Component } from 'react';
import {Card, Button, Form, Select, Divider, Input, notification, Spin} from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios'

const FormItem = Form.Item
const Option = Select.Option

class Items extends Component {

    state = {
        categories: [],
        data: [],
        fields: [],
        selctedCategoryId: undefined,
        loading: false
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
    onSelect = (id)=>{
        const {categories} = this.state
        const category = categories.filter(i=>i.id === id).slice(0)
        console.log(category)
        this.setState({
            fields: category.categoryFields,
            selctedCategoryId: id
        })
    }

    onCancel = ()=>{
        this.setState({
            data: [],
            fields: [],
            selctedCategoryId: undefined
        })
    }

    getParams = ()=>{
        const {selctedCategoryId, fields} = this.state
        const data = {CategoryId: selctedCategoryId,
             Fields: fields.map(i=>({FieldId:i.id, FieldQuery: i.query}))}
        return data
    }

    onSearch = async ()=>{
        this.setState({
            loading: true
        })
        try{
            const response = await axios.post('/api/item/search', this.getParams())
            this.setState({
                data: response.data.data,
                loading: false
            })
        }catch(error){
            this.setState({
                loading: false
            })
            notification.error({ 
                message: "Error",
                description: "Erorr occured, please try again"})
        }

    }

    onAddQuery =(id) =>{
        return (query)=>{
            const {fields} = this.state
            const updatedFields = fields.map(i=>{
                if(i.id === id){
                    i.query = query.target.value
                    return i
                }
                return i
            })
            this.setState({
                fields: updatedFields
            })
        }
    }
  componentWillMount = async () =>{
    await this.loadCategories();
  }


  render() {
    const {categories, data, fields, selctedCategoryId, loading} = this.state
    console.log(fields)
    return (
        <Spin spinning={loading}>
            <br />
            <h3>
                Search items
            </h3>
            <Form layout="inline">
                    <FormItem label="Select category">
                        <Select 
                            style={{width:150}} 
                            value={selctedCategoryId} 
                            onSelect={this.onSelect}>
                        {categories && categories.map(i=>{
                            return (<Option value={i.id} key={i.id}>{i.name}</Option>)
                        })}
                        </Select>
                    </FormItem><br/>
                    {fields && fields.map(i=> {
                        return (
                            <FormItem key={i.id} label={i.name}>
                                <Input onChange={this.onAddQuery(i.id)} value={i.query}/>
                            </FormItem>
                        )
                    })}<br/>
                    <Button type="primary" icon="search" onClick={this.onSearch}>Search</Button>
                    <Button type="danger" onClick={this.onCancel}>Cancel</Button>
            </Form>
            <Divider/>
            {data && data.map(i=>{
                return (
                <div key={i.id}>
                <Card title={i.name} hoverable>
                    <p><b>Description</b> {i.description}</p>
                    <p><b>Price</b> {i.price}</p>
                    {i.itemValues && i.itemValues.map(j=>{
                        return (<p key={j.fieldDto.id}><b>{j.fieldDto.name}</b> {j.fieldValue}</p>)
                    })}
                </Card><br/></div>)
            })}

        </Spin>
    );
  }
}

export default Form.create()(Items);
