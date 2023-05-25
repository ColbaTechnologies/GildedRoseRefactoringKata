import React from "react";
import { Items } from "./item";
import { Table, Thead, Tbody, Tr, Th, Td, TableCaption, TableContainer, Divider } from '@chakra-ui/react'

export const ItemsTable: React.FC<{items: Items, day: number}> = ({items, day}) => <>
    <Table variant='simple'>
        <TableCaption>DAY {day}</TableCaption>
        <Thead>
            <Tr>
                <Th>NAME</Th>
                <Th>SELL IN</Th>
                <Th>QUALITY</Th>
            </Tr>
        </Thead>
        <Tbody>{
            items.map(item => 
                <Tr key={item.name+item.sellIn+item.quality}>
                    <Td>{item.name}</Td>
                    <Td>{item.sellIn}</Td>
                    <Td>{item.quality}</Td>
                </Tr>)
        }</Tbody>
    </Table>
</>;

export const HistoryItemTable: React.FC<{history: {day: number; items: Items}[]}> = ({history}) => <>{
    history.map(historyElement => 
        <TableContainer>
            <ItemsTable items={historyElement.items} day={historyElement.day}/>
            <Divider />
            <br></br>
        </TableContainer>
)}</>;