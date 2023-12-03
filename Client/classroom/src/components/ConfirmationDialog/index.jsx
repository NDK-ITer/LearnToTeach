import React from 'react';
import { Button, Dialog, DialogTitle, DialogContent, DialogActions } from '@material-ui/core';

const ConfirmationDialog = ({ open, onClose, onConfirm, message }) => {
  const handleConfirm = () => {
    onConfirm();
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Confirmation</DialogTitle>
      <DialogContent dividers>
        <p>{message}</p>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleConfirm} color="primary">
          Yes
        </Button>
        <Button onClick={onClose} color="secondary">
          No
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default ConfirmationDialog;
