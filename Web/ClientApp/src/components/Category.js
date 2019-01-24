import React, { Component } from 'react';
import {Table, Button, Divider, notification} from 'antd'
import 'antd/dist/antd.css';
import AddCategoryModal from './AddCategoryModal';
import axios from 'axios'

class Category extends Component {

    state = {
        isAddModalVisible: false,
        data: []
    }

    constructor(props){
        super(props)
        this.columns = [
            {
                title: "Name",
                dataIndex: "name"
            },
            {
                title: "Description",
                dataIndex: "description"
            },
            {
                title: "Action",
                render: (record) => {
                    return (<Button type="danger" onClick={()=>this.onDelete(record.id)}>Delete</Button>)
                }
            }
        ]
    }

    loadCategories = async ()=>{
        try{
            const response = await axios.get('/api/category')
            this.setState({
                data: response.data.data
            })
        }catch(error){
            notification.error({ 
                message: "Error",
                description: "Erorr occured, please try again"})
        }
    }
  componentWillMount = async () =>{
    await this.loadCategories();
  }

  openAddModal = ()=>{
      this.setState({
          isAddModalVisible: true
      })
  }

  closeAddModal =()=>{
    this.setState({
        isAddModalVisible: false
    })
  }

  onCreate = async (data)=> {
    var postData = {Name: data.name, Description: data.description, 
        CategoryFieldNames: data.CategoryFieldNames, CategoryFieldTypes: data.CategoryFieldTypes}
    console.log(postData)
    try{
        await axios.post('/api/category', postData)
        notification.success({ 
            message: "Success", 
            description:"Category has been successfully created"
        })
        this.loadCategories()
    }catch(error){
    notification.error({ 
        message: "Error",
        description: "Erorr occured, please try again"})

    }
 }
  
 onDelete = async (id)=> {
     console.log(id)
    try{
        await axios.delete('/api/category', {params:{id:id}})
        notification.success({ 
            message: "Success", 
            description:"Category has been successfully deleted"
        })
        this.loadCategories()
    }catch(error){
    notification.error({ 
        message: "Error",
        description: "Erorr occured, please try again"})

    }
 }
  render() {
      const {isAddModalVisible, data} = this.state
    return (
        <div>
            <br />
            <h3>
                Category
                <Button type="primary"
                    className="pull-right"
                    onClick={this.openAddModal}
                >
                    Add new category
                </Button>
            </h3>
            <Divider/>
            <Table 
                rowKey={record=>record.name}
                columns={this.columns}
                dataSource={data}
            />
            {isAddModalVisible &&
                <AddCategoryModal
                    onCreate={this.onCreate}
                    onClose={this.closeAddModal}
                />
            }
        </div>
    );
  }
}

export default Category;
